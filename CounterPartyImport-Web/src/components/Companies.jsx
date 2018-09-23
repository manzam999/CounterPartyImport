import React, { Component } from 'react';
import { Table } from 'semantic-ui-react';

class Companies extends Component {
  render() {
    return (
      <Table celled>
        <Table.Header>
          <Table.Row>
            <Table.HeaderCell>ExternalId</Table.HeaderCell>
            <Table.HeaderCell>TradingName</Table.HeaderCell>
            <Table.HeaderCell>LegalName</Table.HeaderCell>
            <Table.HeaderCell>Phone</Table.HeaderCell>
            <Table.HeaderCell>Fax</Table.HeaderCell>
            <Table.HeaderCell>IsForwarder</Table.HeaderCell>
            <Table.HeaderCell>IsActive</Table.HeaderCell>
          </Table.Row>
        </Table.Header>

        <Table.Body>
          {this.props.companies.map((company) => {
            return (<Table.Row key={company.externalId}>
              <Table.Cell>{company.externalId}</Table.Cell>
              <Table.Cell>{company.tradingName}</Table.Cell>
              <Table.Cell>{company.legalName}</Table.Cell>
              <Table.Cell>{company.phone}</Table.Cell>
              <Table.Cell>{company.fax}</Table.Cell>
              <Table.Cell>{company.isForwarder ? "Yes" : "No"}</Table.Cell>
              <Table.Cell>{company.isActive ? "Yes" : "No"}</Table.Cell>
            </Table.Row>)
          })}
        </Table.Body>
      </Table>
    );
  }
}

export default Companies;
