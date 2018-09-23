import React, { Component } from 'react';
import Dropzone from 'react-dropzone';
import axios from 'axios';
import { CounterPartyImportUrl } from '../constants/UrlConstants'
import { Button, Modal, Icon, Header, Container } from 'semantic-ui-react';
import Companies from './Companies';

class App extends Component {
  constructor(props) {
    super(props);

    this.state = {
      companies: [],
      files: [],
      modalOpen: false
    }
  }

  componentDidMount() {
    this.setCompanies();
  }

  onDrop(files) {
    this.setState({
      files: files
    });
  }

  handleOpen = () => { this.setState({modalOpen: true}); };
  handleClose = () => { this.setState({modalOpen: false}); };

  import() {
    var formData = new FormData();
    formData.append('', this.state.files[0]);

    axios(`${CounterPartyImportUrl}Company/Import`, {
      method: 'post',
      data: formData,
      config: { headers: { 'Content-Type': 'multipart/form-data' } }
    }).then(res => {
      this.setCompanies();
      this.handleClose();
      this.remove();
    })
  }

  setCompanies() {
    axios.get(`${CounterPartyImportUrl}Company`)
      .then(res => {
        this.setState({
          companies: res.data
        });
      })
  }

  remove() {
    this.setState({
      files: []
    })
  }

  render() {
    return (
      <Container>
        <Modal open={this.state.modalOpen} trigger={<Button onClick={this.handleOpen}>Import</Button>}>
          <Modal.Content>
            {this.state.files.length ? (<div> {this.state.files[0].name} <Button onClick={this.remove.bind(this)}> Remove File </Button> </div>) :
              (<Dropzone accept=".csv, application/vnd.openxmlformats-officedocument.spreadsheetml.sheet, application/vnd.ms-excel" multiple={false} onDrop={this.onDrop.bind(this)}>
                <div>Drag file here</div>
              </Dropzone>)}
          </Modal.Content>
          <Modal.Actions>
            <Button onClick={this.import.bind(this)} primary>
              Proceed <Icon name='right chevron' />
            </Button>
          </Modal.Actions>
        </Modal>
        {this.state.companies.length ? <Companies companies={this.state.companies} /> : <Header> No data </Header>}
      </Container>
    );
  }
}

export default App;
