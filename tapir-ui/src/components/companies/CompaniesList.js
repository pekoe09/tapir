import React from 'react'
import { connect } from 'react-redux'
import { getAllCompanies } from '../../actions/companyActions'
import TapirHeader from '../ui-structure/TapirHeader'

class CompaniesList extends React.Component {

  componentDidMount = async () => {
    await this.props.getAllCompanies()
  }

  render() {
    return (
      <div>
        <TapirHeader
          title='Companies'
        >
          <button style={{ float: 'right' }}>Add company</button>
        </TapirHeader>
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