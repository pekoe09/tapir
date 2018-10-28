import React from 'react'
import { connect } from 'react-redux'
import { Navbar, FormGroup, FormControl , Button, ControlLabel} from 'react-bootstrap'
import { getAllSectors } from '../../actions/sectorActions'
import { getAllCompanies } from '../../actions/companyActions'
import Login from './Login'

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
        <Navbar.Form pullright>
          <Login />
        </Navbar.Form>
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