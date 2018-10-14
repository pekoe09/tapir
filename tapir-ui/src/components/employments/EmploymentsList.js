import React from 'react'
import { withRouter } from 'react-router-dom'
import { connect } from 'react-redux'
import moment from 'moment'
import { getAllEmployments, deleteEmployment } from '../../actions/employmentActions'
import { addUIMessage } from '../../actions/uiMessageActions'
import TapirHeader from '../ui-structure/TapirHeader'
import { StyledReactTable, StyledLinkButton, StyledButton } from '../ui-structure/StyledComponents'
import { Modal } from 'react-bootstrap'

class EmploymentsList extends React.Component {

  constructor(props) {
    super(props)
    this.state = {
      deleteConfirmVisible: false,
      rowToDelete: null
    }
  }

  componentDidMount = async () => {
    await this.props.getAllEmployments()
  }

  handleRowClick = (state, rowInfo) => {
    return {
      onClick: (e) => {
        this.props.history.push(`/employments/edit/${rowInfo.original.id}`)
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
    this.props.deleteEmployment(rowToDelete.id)
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
      Header: 'Person',
      accessor: 'personFullName',
      headerStyle: {
        textAlign: 'left'
      }
    },
    {
      Header: 'Company',
      accessor: 'companyFullName',
      headerStyle: {
        textAlign: 'left'
      }
    },
    {
      Header: 'Start date',
      accessor: 'startDate',
      Cell: row => (moment(row.original.startDate).format('DD.MM.YYYY')),
      headerStyle: {
        textAlign: 'center'
      },
      style: {
        textAlign: 'center'
      },
      maxWidth: 150
    },
    {
      Header: 'End date',
      accessor: 'endDate',
      Cell: row => (row.original.endDate ? moment(row.original.endDate).format('DD.MM.YYYY') : ''),
      headerStyle: {
        textAlign: 'center'
      },
      style: {
        textAlign: 'center'
      },
      maxWidth: 150
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
        <TapirHeader title='Employments'>
          <StyledLinkButton
            style={{ float: 'right' }}
            to={'/employments/add'}
            text={'Add employment'}
            type={'primary'}
          />
        </TapirHeader>
        <StyledReactTable
          data={this.props.employments}
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
  employments: store.employments.items,
  error: store.employments.error
})

export default withRouter(connect(
  mapStateToProps,
  {
    getAllEmployments,
    deleteEmployment,
    addUIMessage
  }
)(EmploymentsList))