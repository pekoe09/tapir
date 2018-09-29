import React from 'react'
import { connect } from 'react-redux'
import { getAllCompanies } from '../../actions/companyActions'
import TapirHeader from '../ui-structure/TapirHeader'
import { StyledReactTable, StyledLinkButton, StyledButton, StyleModal, StyledModal } from '../ui-structure/StyledComponents'
import { Modal } from 'react-bootstrap'

class CompaniesList extends React.Component {

  constructor(props) {
    super(props)
    this.state = {
      deleteConfirmVisible: false,
      rowToDelete: null
    }
  }

  componentDidMount = async () => {
    await this.props.getAllCompanies()
  }

  handleDelete = (row, e) => {
    e.stopPropagation()
    this.setState({
      deleteConfirmVisible: true,
      rowToDelete: row
    })
  }

  handleConfirmedDelete= async () => {
    const fullName = this.state.rowToDelete.fullName
    this.setState({
      deleteConfirmVisible: false,
      rowToDelete: null
    })
    // call remove method
    // if not error, add success message, else add failure message
  }

  handleCancelledDelete = () => {
    this.setState({
      deleteConfirmVisible: false,
      rowToDelete: null
    })
  }

  columns = [
    {
      Header: 'Name',
      accessor: 'fullName',
      headerStyle: {
        textAlign: 'left'
      }
    },
    {
      Header: 'Short name',
      accessor: 'shortName',
      headerStyle: {
        textAlign: 'left'
      }
    },
    {
      Header: '',
      accessor: 'delete',
      Cell: (row) => (
        <StyledButton
          btntype='rowdanger'
          onClick={(e) => this.handleDelete(row.original, e)}
        >
          Delete
        </StyledButton>
      ),
      style: {
        textAlign: 'center'
      },
      sortable: false,
      filterable: false,
      maxWidth: 80
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

        <Modal show={this.state.deleteConfirmVisible}>
          <Modal.Header>
            Deleting {this.state.rowToDelete ? this.state.rowToDelete.fullName : ''}
          </Modal.Header>
          <Modal.Body>
            Are you sure you want to delete {this.state.rowToDelete ? this.state.rowToDelete.fullName : ''}?
          </Modal.Body>
          <Modal.Footer>
            <StyledButton
              btntype='primary'
              onClick={this.handleConfirmedDelete}
            >
              Yes, delete
            </StyledButton>
            <StyledButton
              btntype='default'
              onClick={this.handleCancelledDelete}
            >
              Cancel
            </StyledButton>
          </Modal.Footer>
        </Modal>
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