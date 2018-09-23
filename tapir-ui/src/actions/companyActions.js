import companiesService from '../services/companyService'

export const COMPANIES_GETALL_BEGIN = 'COMPANIES_GETALL_BEGIN'
export const COMPANIES_GETALL_SUCCESS = 'COMPANIES_GETALL_SUCCESS'
export const COMPANIES_GETALL_FAILURE = 'COMPANIES_GETALL_FAILURE'

const getAllCompaniesBegin = () => ({
  type: COMPANIES_GETALL_BEGIN
})

const getAllCompaniesSuccess = companies => ({
  type: COMPANIES_GETALL_SUCCESS,
  payload: { companies }
})

const getAllCompaniesFailure = error => ({
  type: COMPANIES_GETALL_FAILURE,
  payload: { error }
})

export const getAllCompanies = () => {
  return async (dispatch) => {
    dispatch(getAllCompaniesBegin())
    try {
      const companies = await companiesService.getAll()
      dispatch(getAllCompaniesSuccess(companies))
    } catch (error) {
      console.log(error)
      dispatch(getAllCompaniesFailure(error))
    }
  }
}