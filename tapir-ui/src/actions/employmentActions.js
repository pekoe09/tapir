import employmentService from '../services/employmentService'

export const EMPLOYMENTS_GETALL_BEGIN = 'EMPLOYMENTS_GETALL_BEGIN'
export const EMPLOYMENTS_GETALL_SUCCESS = 'EMPLOYMENTS_GETALL_SUCCESS'
export const EMPLOYMENTS_GETALL_FAILURE = 'EMPLOYMENTS_GETALL_FAILURE'
export const EMPLOYMENT_CREATE_BEGIN = 'EMPLOYMENT_CREATE_BEGIN'
export const EMPLOYMENT_CREATE_SUCCESS = 'EMPLOYMENT_CREATE_SUCCESS'
export const EMPLOYMENT_CREATE_FAILURE = 'EMPLOYMENT_CREATE_FAILURE'
export const EMPLOYMENT_UPDATE_BEGIN = 'EMPLOYMENT_UPDATE_BEGIN'
export const EMPLOYMENT_UPDATE_SUCCESS = 'EMPLOYMENT_UPDATE_SUCCESS'
export const EMPLOYMENT_UDPATE_FAILURE = 'EMPLOYMENT_UPDATE_FAILURE'
export const EMPLOYMENT_DELETE_BEGIN = 'EMPLOYMENT_DELETE_BEGIN'
export const EMPLOYMENT_DELETE_SUCCESS = 'EMPLOYMENT_DELETE_SUCCESS'
export const EMPLOYMENT_DELETE_FAILURE = 'EMPLOYMENT_DELETE_FAILURE'

const getAllEmploymentsBegin = () => ({
  type: EMPLOYMENTS_GETALL_BEGIN
})

const getAllEmploymentsSuccess = employments => ({
  type: EMPLOYMENTS_GETALL_SUCCESS,
  payload: { employments }
})

const getAllEmploymentsFailure = error => ({
  type: EMPLOYMENTS_GETALL_FAILURE,
  payload: { error }
})

const addEmploymentBegin = () => ({
  type: EMPLOYMENT_CREATE_BEGIN
})

const addEmploymentSuccess = employment => ({
  type: EMPLOYMENT_CREATE_SUCCESS,
  payload: { employment }
})

const addEmploymentFailure = error => ({
  type: EMPLOYMENT_CREATE_FAILURE,
  payload: { error }
})

const updateEmploymentBegin = () => ({
  type: EMPLOYMENT_UPDATE_BEGIN
})

const updateEmploymentSuccess = employment => ({
  type: EMPLOYMENT_UPDATE_SUCCESS,
  payload: { employment }
})

const updateEmploymentFailure = error => ({
  type: EMPLOYMENT_UDPATE_FAILURE,
  payload: { error }
})

const deleteEmploymentBegin = () => ({
  type: EMPLOYMENT_DELETE_BEGIN
})

const deleteEmploymentSuccess = employment => ({
  type: EMPLOYMENT_DELETE_SUCCESS,
  payload: { employment }
})

const deleteEmploymentFailure = error => ({
  type: EMPLOYMENT_DELETE_FAILURE,
  payload: { error }
})

export const getAllEmployments = () => {
  return async (dispatch) => {
    dispatch(getAllEmploymentsBegin())
    try {
      const employments = await employmentService.getAll()
      dispatch(getAllEmploymentsSuccess(employments))
    } catch (error) {
      console.log(error)
      dispatch(getAllEmploymentsFailure(error))
    }
  }
}

export const addEmployment = (employment) => {
  return async (dispatch) => {
    dispatch(addEmploymentBegin())
    try {
      employment = await employmentService.addEmployment(employment)
      dispatch(addEmploymentSuccess(employment))
    } catch (error) {
      console.log(error)
      dispatch(addEmploymentFailure(error))
    }
  }
}

export const updateEmployment = (employment) => {
  return async (dispatch) => {
    dispatch(updateEmploymentBegin())
    try {
      employment = await employmentService.updateEmployment(employment)
      dispatch(updateEmploymentSuccess(employment))
    } catch (error) {
      console.log(error)
      dispatch(updateEmploymentFailure(error))
    }
  }
}

export const deleteEmployment = (id) => {
  return async (dispatch) => {
    dispatch(deleteEmploymentBegin())
    try {
      const employment = await employmentService.removeEmployment(id)
      dispatch(deleteEmploymentSuccess(employment))
    } catch (error) {
      console.log(error)
      dispatch(deleteEmploymentFailure(error))
    }
  }
}