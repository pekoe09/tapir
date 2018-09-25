import React from 'react'
import { connect } from 'react-redux'
import { getAllCompanies } from '../../actions/companyActions'

class CompaniesList extends React.Component {

  componentDidMount = async () => {
    await this.props.getAllCompanies()
  }

  render() {
    return (
      <div>
        <h2>Companies</h2>
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