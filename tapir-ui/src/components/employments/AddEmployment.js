import React from 'react'
import { connect } from 'react-redux'
import { withRouter } from 'react-router-dom'
import { addEmployment } from '../../actions/employmentActions'
import { addUIMessage } from '../../actions/uiMessageActions'
import TapirHeader from '../ui-structure/TapirHeader'
import {
  StyledLinkButton,
  StyledButton,
  StyledForm,
  StyledSubForm,
  StyledFormControl,
  StyledCol,
  StyledSubFormBordered
} from '../ui-structure/StyledComponents'
import { FormGroup, ControlLabel, Col, Radio, Collapse } from 'react-bootstrap'
import { Typeahead } from 'react-bootstrap-typeahead'

class AddEmployment extends React.Component {

  constructor(props) {
    super(props)
    this.state = {
      company: null,
      person: null,
      startDate: '',
      endDate: '',
      isTemporary: false,
      plannedEndDate: '',
      isMainOccupation: true,
      isFullTime: false,
      isCalledToWork: false,
      weeklyHours: '',
      partTimeDailyHours: '',
      partTimeWeeklyDays: '',
      partTimeEmploymentReason: '',
      isStudent: '',
      schoolName: '',
      isPensioner: '',
      pensionPlan: '',
      pensionStartDate: '',
      isPensionAppliedFor: '',
      pensionFundName: '',
      entrepreneurshipStatus: '',
      hasOtherEmployments: '',
      otherEmployerName: '',
      otherEmploymentContactDetails: ''
    }
  }

  handleChange = (event) => {
    this.setState({ [event.target.name]: event.target.value })
  }

  handleSelectionChange = (selected, field) => {
    this.setState({ [field]: selected })
  }

  handleTemporaryToggle = (e) => {
    this.setState({ isTemporary: e.currentTarget.value === 'true' })
    if (e.currentTarget.value !== 'true') {
      this.setState({ plannedEndDate: '' })
    }
  }

  handleFullTimeToggle = (e) => {
    this.setState({ isFullTime: e.currentTarget.value === 'true' })
    if (e.currentTarget.value !== 'true') {
      this.setState({
        partTimeDailyHours: '',
        partTimeWeeklyDays: '',
        partTimeEmploymentReason: ''
      })
    }
  }

  handleMainOccupationToggle = (e) => {
    this.setState({ isMainOccupation: e.currentTarget.value === 'true' })
  }

  handleCalledToWorktoggle = (e) => {
    this.setState({ isCalledToWork: e.currentTarget.value === 'true' })
  }

  handleOtherEmploymentsToggle = (e) => {
    this.setState({
      hasOtherEmployments:
        e.currentTarget.value === 'true' ? true :
          e.currentTarget.value === 'false' ? false : ''})
    if (e.currentTarget.value !== 'true') {
      this.setState({
        otherEmployerName: '',
        otherEmploymentContactDetails: ''
      })
    }
  }

  handleStudentToggle = (e) => {
    this.setState({ isStudent: e.currentTarget.value === 'true' })
    if (e.currentTarget.value !== 'true') {
      this.setState({ schoolName: '' })
    }
  }

  handlePensionerToggle = (e) => {
    this.setState({ isPensioner: e.currentTarget.value === 'true' })
    if (e.currentTarget.value !== 'true') {
      this.setState({
        pensionPlan: '',
        pensionStartDate: ''
      })
    }
  }

  handlePensionApplicationToggle = (e) => {
    this.setState({ isPensionAppliedFor: e.currentTarget.value === 'true' })
    if (e.currentTarget.value !== 'true') {
      this.setState({ pensionFundName: '' })
    }
  }

  handleSubmit = async (event) => {
    event.preventDefault()
    const employment = {
      company: this.state.company,
      person: this.state.person,
      startDate: this.state.startDate,
      endDate: this.state.endDate,
      plannedEndDate: this.state.endDate,
      isMainOccupation: this.state.isMainOccupation,
      isFullTime: this.state.isFullTime,
      isCalledToWork: this.state.isCalledToWork,
      weeklyHours: this.state.weeklyHours,
      partTimeDailyHours: this.state.partTimeDailyHours,
      partTimeWeeklyDays: this.state.partTimeWeeklyDays,
      partTimeEmploymentReason: this.state.partTimeEmploymentReason,
      isStudent: this.state.isStudent,
      schoolName: this.state.schoolName,
      isPensioner: this.state.isPensioner,
      pensionPlan: this.state.pensionPlan,
      pensionStartDate: this.state.pensionStartDate,
      isPensionAppliedFor: this.state.isPensionAppliedFor,
      pensionFundName: this.state.pensionFundName,
      entrepreneurshipStatus: this.state.entrepreneurshipStatus,
      hasOtherEmployments: this.state.hasOtherEmployments,
      otherEmployerName: this.state.otherEmployerName,
      otherEmploymentContactDetails: this.state.otherEmploymentContactDetails
    }
    await this.props.addEmployment(employment)
    if (!this.props.error) {
      this.props.addUIMessage('Added employment ' + this.state.person.fullName + '/' + this.state.company.fullName)
      this.clearState()
      this.props.history.push('/employments')
    } else {
      this.props.addUIMessage('Could not add the employment', 'danger', 10)
    }
  }

  clearState = () => {
    this.setState({
      company: null,
      person: null,
      startDate: '',
      endDate: '',
      isTemporary: false,
      plannedEndDate: '',
      isMainOccupation: false,
      isFullTime: false,
      isCalledToWork: false,
      weeklyHours: '',
      partTimeDailyHours: '',
      partTimeWeeklyDays: '',
      partTimeEmploymentReason: '',
      isStudent: '',
      schoolName: '',
      isPensioner: '',
      pensionPlan: '',
      pensionStartDate: '',
      isPensionAppliedFor: '',
      pensionFundName: '',
      entrepreneurshipStatus: '',
      hasOtherEmployments: '',
      otherEmployerName: '',
      otherEmploymentContactDetails: ''
    })
  }

  render() {
    return (
      <div>
        <TapirHeader title='Add a new Employment relationship'>
          <StyledLinkButton
            style={{ float: 'right' }}
            to={'/companies'}
            text={'Cancel'}
            type={'default'}
          />
        </TapirHeader>
        <StyledForm>
          <Col sm={6} style={{ marginBottom: 20 }}>
            <FormGroup controlId='employmentCompany'>
              <ControlLabel>Company</ControlLabel>
              <Typeahead
                options={this.props.companies}
                onChange={(selected) => { this.handleSelectionChange(selected, 'company') }}
                selected={this.state.company}
                labelKey='fullName'
                ignoreDiacritics={false}
                minLength={3}
                selectHintOnEnter={true}
              />
            </FormGroup>
            <FormGroup controlId='employmentPerson'>
              <ControlLabel>Person</ControlLabel>
              <Typeahead
                options={this.props.persons}
                onChange={(selected) => { this.handleSelectionChange(selected, 'person') }}
                selected={this.state.person}
                labelKey='fullName'
                ignoreDiacritics={false}
                minLength={3}
                selectHintOnEnter={true}
              />
            </FormGroup>
            <ControlLabel>Is the employment temporary?</ControlLabel>
            <FormGroup controlId='employmentIsTemporary'>
              <Radio
                name='isTemporary'
                value={false}
                checked={!this.state.isTemporary}
                onChange={this.handleTemporaryToggle}
                inline
              >
                No
              </Radio>{' '}
              <Radio
                name='isTemporary'
                value={true}
                checked={this.state.isTemporary}
                onChange={this.handleTemporaryToggle}
                inline
              >
                Yes
              </Radio>
            </FormGroup>
            <StyledSubForm componentClass='fieldset' style={{ marginBottom: 0 }}>
              <StyledCol sm={4} style={{ paddingRight: 7 }}>
                <FormGroup controlId='employmentStartDate'>
                  <ControlLabel>Start date</ControlLabel>
                  <StyledFormControl
                    name='startDate'
                    type='text'
                    value={this.state.startDate}
                    onChange={this.handleChange}
                  />
                </FormGroup>
              </StyledCol>
              <StyledCol sm={4} style={{ paddingRight: 7 }}>
                <FormGroup controlId='employmentEndDate'>
                  <ControlLabel>End date</ControlLabel>
                  <StyledFormControl
                    name='endDate'
                    type='text'
                    value={this.state.endDate}
                    onChange={this.handleChange}
                  />
                </FormGroup>
              </StyledCol>
              <Collapse in={this.state.isTemporary}>
                <StyledCol sm={4} style={{ paddingLeft: 7 }}>
                  <FormGroup controlId='employmentPlannedEndDate'>
                    <ControlLabel>Temp end date</ControlLabel>
                    <StyledFormControl
                      name='plannedEndDate'
                      type='text'
                      value={this.state.plannedEndDate}
                      onChange={this.handleChange}
                    />
                  </FormGroup>
                </StyledCol>
              </Collapse>
            </StyledSubForm>
            <ControlLabel>Is this employment the main occupation?</ControlLabel>
            <FormGroup controlId='employmentIsMainOccupation'>
              <Radio
                name='isMainOccupation'
                value={true}
                checked={this.state.isMainOccupation}
                onChange={this.handleMainOccupationToggle}
                inline
              >
                Yes
              </Radio>{' '}
              <Radio
                name='isMainOccupation'
                value={false}
                checked={!this.state.isMainOccupation}
                onChange={this.handleMainOccupationToggle}
                inline
              >
                No
              </Radio>
            </FormGroup>
            <ControlLabel>Is the person called to work?</ControlLabel>
            <FormGroup controlId='employmentIsCalledToWork'>
              <Radio
                name='isCalledToWork'
                value={false}
                checked={!this.state.isCalledToWork}
                onChange={this.handleCalledToWorktoggle}
                inline
              >
                No
              </Radio>{' '}
              <Radio
                name='isCalledToWork'
                value={true}
                checked={this.state.isCalledToWork}
                onChange={this.handleCalledToWorktoggle}
                inline
              >
                Yes
              </Radio>
            </FormGroup>
            <ControlLabel>Is the employment part-time?</ControlLabel>
            <FormGroup controlId='employmentIsPartTime'>
              <Radio
                name='isFullTime'
                value={false}
                checked={!this.state.isFullTime}
                onChange={this.handleFullTimeToggle}
                inline
              >
                No
              </Radio>{' '}
              <Radio
                name='isFullTime'
                value={true}
                checked={this.state.isFullTime}
                onChange={this.handleFullTimeToggle}
                inline
              >
                Yes
              </Radio>
            </FormGroup>
            <Collapse in={this.state.isFullTime}>
              <StyledSubForm componentClass='fieldset'>
                <StyledSubForm componentClass='fieldset' style={{ marginBottom: 0 }}>
                  <StyledCol sm={2} style={{ paddingRight: 14 }}>
                    <FormGroup controlId='employmentPartTimeDailyHours'>
                      <ControlLabel>Daily hours</ControlLabel>
                      <StyledFormControl
                        name='partTimeDailyHours'
                        type='text'
                        value={this.state.partTimeDailyHours}
                        onChange={this.handleChange}
                      />
                    </FormGroup>
                  </StyledCol>
                  <StyledCol sm={2}>
                    <FormGroup controlId='employmentPartTimeWeeklyDays'>
                      <ControlLabel>Weekly days</ControlLabel>
                      <StyledFormControl
                        name='partTimeWeeklyDays'
                        type='text'
                        value={this.state.partTimeWeeklyDays}
                        onChange={this.handleChange}
                      />
                    </FormGroup>
                  </StyledCol>
                </StyledSubForm>
                <FormGroup controlId='employmentPartTimeEmploymentReason'>
                  <ControlLabel>Reason for part time employment</ControlLabel>
                  <StyledFormControl
                    name='partTimeEmploymentReason'
                    type='text'
                    value={this.state.partTimeEmploymentReason}
                    onChange={this.handleChange}
                  />
                </FormGroup>
              </StyledSubForm>
            </Collapse>
            <ControlLabel>Are there other employers?</ControlLabel>
            <FormGroup controlId='employmentOtherEmployers'>
              <Radio
                name='hasOtherEmployments'
                value={''}
                checked={this.state.hasOtherEmployments === ''}
                onChange={this.handleOtherEmploymentsToggle}
                inline
              >
                Not known
              </Radio>
              <Radio
                name='hasOtherEmployments'
                value={true}
                checked={this.state.hasOtherEmployments}
                onChange={this.handleOtherEmploymentsToggle}
                inline
              >
                Yes
              </Radio>{' '}
              <Radio
                name='hasOtherEmployments'
                value={false}
                checked={this.state.hasOtherEmployments === false}
                onChange={this.handleOtherEmploymentsToggle}
                inline
              >
                No
              </Radio>
            </FormGroup>
            <Collapse in={this.state.hasOtherEmployments === true}>
              <StyledSubForm componentClass='fieldset'>
              <FormGroup controlId='employmentOtherEmployerName'>
                <ControlLabel>Name of the other employer</ControlLabel>
                <StyledFormControl
                  name='otherEmployerName'
                  type='text'
                  value={this.state.otherEmployerName}
                  onChange={this.handleChange}
                />
              </FormGroup>
              <FormGroup controlId='employmentOtherEmploymentContactDetails'>
                <ControlLabel>Contact details for other employer</ControlLabel>
                <StyledFormControl
                  name='otherEmploymentContactDetails'
                  type='text'
                  value={this.state.otherEmploymentContactDetails}
                  onChange={this.handleChange}
                />
                </FormGroup>
              </StyledSubForm>
            </Collapse>
            <ControlLabel>Is the person a student?</ControlLabel>
            <FormGroup controlId='employmentStudent'>
              <Radio
                name='isStudent'
                value={''}
                checked={this.state.isStudent === ''}
                onChange={this.handleStudentToggle}
                inline
              >
                Not known
              </Radio>
              <Radio
                name='isStudent'
                value={true}
                checked={this.state.isStudent}
                onChange={this.handleStudentToggle}
                inline
              >
                Yes
              </Radio>{' '}
              <Radio
                name='isStudent'
                value={false}
                checked={this.state.isStudent === false}
                onChange={this.handleStudentToggle}
                inline
              >
                No
              </Radio>
            </FormGroup>
            <Collapse in={this.state.isStudent === true}>
              <StyledSubForm componentClass='fieldset'>
                <FormGroup controlId='employmentSchoolName'>
                  <ControlLabel>Name of the place of study</ControlLabel>
                  <StyledFormControl
                    name='schoolName'
                    type='text'
                    value={this.state.schoolName}
                    onChange={this.handleChange}
                  />
                </FormGroup>
              </StyledSubForm>
            </Collapse>
            <ControlLabel>Is the person a pensioner?</ControlLabel>
            <FormGroup controlId='employmentIsPensioner'>
              <Radio
                name='isPensioner'
                value={false}
                checked={!this.state.isPensioner}
                onChange={this.handlePensionerToggle}
                inline
              >
                No
              </Radio>{' '}
              <Radio
                name='isPensioner'
                value={true}
                checked={this.state.isPensioner}
                onChange={this.handlePensionerToggle}
                inline
              >
                Yes
              </Radio>
            </FormGroup>
            <Collapse in={this.state.isPensioner === true}>
              <StyledSubForm componentClass='fieldset'>
                <StyledCol sm={8} style={{ paddingRight: 7 }}>
                  <FormGroup controlId='employmentPensionPlan'>
                    <ControlLabel>Pension plan</ControlLabel>
                    <StyledFormControl
                      name='pensionPlan'
                      type='text'
                      value={this.state.pensionPlan}
                      onChange={this.handleChange}
                    />
                  </FormGroup>
                </StyledCol>
                <StyledCol sm={4}>
                  <FormGroup controlId='employmentPensionStartDate'>
                    <ControlLabel>Pension start date</ControlLabel>
                    <StyledFormControl
                      name='pensionStartDate'
                      type='text'
                      value={this.state.pensionStartDate}
                      onChange={this.handleChange}
                    />
                  </FormGroup>
                </StyledCol>
              </StyledSubForm>
            </Collapse>
            <ControlLabel>Is pension application in process?</ControlLabel>
            <FormGroup controlId='employmentHasAppliedForPension'>
              <Radio
                name='isPensionAppliedFor'
                value={false}
                checked={!this.state.isPensionAppliedFor}
                onChange={this.handlePensionApplicationToggle}
                inline
              >
                No
              </Radio>{' '}
              <Radio
                name='isPensionAppliedFor'
                value={true}
                checked={this.state.isPensionAppliedFor}
                onChange={this.handlePensionApplicationToggle}
                inline
              >
                Yes
              </Radio>
            </FormGroup>
            <Collapse in={this.state.isPensionAppliedFor === true}>
              <FormGroup controlId='employmentPensionFund'>
                <ControlLabel>Pension company/fund</ControlLabel>
                <StyledFormControl
                  name='pensionFundName'
                  type='text'
                  value={this.state.pensionFundName}
                  onChange={this.handleChange}
                />
              </FormGroup>
            </Collapse>

            <FormGroup>
              <StyledButton
                type='primary'
                onClick={this.handleSubmit}
              >
                Save
              </StyledButton>
            </FormGroup>
          </Col>
        </StyledForm>
      </div>
    )
  }
}

const mapStateToProps = store => ({
  error: store.employments.error,
  companies: store.companies.items,
  persons: store.persons.items.map(p => {
    return {
      ...p,
      fullName: `${p.lastName}, ${p.firstNames}`
    }
  })
})

export default withRouter(connect(
  mapStateToProps,
  {
    addEmployment,
    addUIMessage
  }
)(AddEmployment))