import React from 'react'
import { withRouter } from 'react-router-dom'
import { connect } from 'react-redux'
import { getAllPersons, deletePerson } from '../../actions/personActions'
import { addUIMessage } from '../../actions/uiMessageActions'
import TapirHeader from '../ui-structure/TapirHeader'
import { StyledReactTable, StyledLinkButton, StyledButton } from '../ui-structure/StyledComponents'
import { Modal } from 'react-bootstrap'

class PersonsList extends React.Component {

  constructor(props) {
    super(props)
    this.state = {
      deleteConfirmVisible: false,
      rowToDelete: null
    }
  }

  componentDidMount = async () => {
    await this.props.getAllPersons()
  }

  handleRowClick = (state, rowInfo) => {
    return {
      onClick: (e) => {
        this.props.history.push(`/persons/edit/${rowInfo.original.id}`)
      }
    }
  }

  handleDelete = (row, e) => {
    e.stopPropagation()
    this.setState({
      deleteConfirmVisible: true,
      rowToDelete: row
    })
  }

  handleConfirmedDelete = async () => {
    const rowToDelete = this.state.rowToDelete
    this.setState({
      deleteConfirmVisible: false,
      rowToDelete: null
    })
    this.props.deletePerson(rowToDelete.id)
    if (!this.props.error) {
      this.props.addUIMessage('Deleted ' + rowToDelete.fullName, 'success', 10)
    } else {
      this.props.addUIMessage('Could not delete ' + rowToDelete.fullName, 'danger', 10)
    }
  }

  handleCancelledDelete = () => {
    this.setState({
      deleteConfirmVisible: false,
      rowToDelete: null
    })
  }

  columns = [
    {
      Header: 'Last name',
      accessor: 'lastName',
      headerStyle: {
        textAlign: 'left'
      }
    },
    {
      Header: 'First names',
      accessor: 'firstNames',
      headerStyle: {
        textAlign: 'left'
      }
    },
    {
      Header: 'Email',
      accessor: 'email',
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
        <TapirHeader title='Persons'>        
          <StyledLinkButton
            style={{ float: 'right' }}
            to={'/persons/add'}
            text={'Add person'}
            type={'primary'}
          />
        </TapirHeader>
        <StyledReactTable
          data={this.props.persons}
          columns={this.columns}
          getTrProps={this.handleRowClick}
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
  persons: store.persons.items,
  error: store.persons.error
})

export default withRouter(connect(
  mapStateToProps,
  {
    getAllPersons,
    deletePerson,
    addUIMessage
  }
)(PersonsList))