import React from 'react'
import { connect } from 'react-redux'
import { Navbar } from 'react-bootstrap'
import { getAllSectors } from '../../actions/sectorActions'
import { getAllCompanies } from '../../actions/companyActions'

class TapirNavbar extends React.Component {

  componentDidMount = async () => {
    await this.props.getAllSectors()
    await this.props.getAllCompanies()
  }

  render() {
    return (
      <Navbar style={{ marginBottom: 0 }}>
        <Navbar.Header>
          <Navbar.Brand>
            Tapiiri
        </Navbar.Brand>
        </Navbar.Header>
      </Navbar>
    )
  }
}

export default connect(
  null,
  {
    getAllCompanies,
    getAllSectors
  }
)(TapirNavbar)