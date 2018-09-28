import React from 'react'
import { connect } from 'react-redux'
import { getAllCompanies } from '../../actions/companyActions'
import ReactTable from 'react-table'
import TapirHeader from '../ui-structure/TapirHeader'
import { StyledReactTable, StyledLinkButton } from '../ui-structure/StyledComponents'

class CompaniesList extends React.Component {

  componentDidMount = async () => {
    await this.props.getAllCompanies()
  }

  columns = [
    {
      Header: 'Name',
      accessor: 'fullName'
    },
    {
      Header: 'Short name',
      accessor: 'shortName'
    }
  ]

  render() {
    return (
      <div>
        <TapirHeader
          title='Companies'
        >
          <StyledLinkButton
            style={{ float: 'right' }}
            to={'/companies/add'}
            text={'Add company'}
            type={'primary'}
          />
        </TapirHeader>
        <StyledReactTable
          data={this.props.companies}
          columns={this.columns}
          defaultPageSize={50}
          minRows={1}
        />
      </div>
    )
  }
}

const mapStateToProps = store => ({
  companies: store.companies.items
})

export default connect(
  mapStateToProps,
  {
    getAllCompanies
  }
)(CompaniesList)