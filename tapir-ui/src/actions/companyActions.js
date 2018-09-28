import companiesService from '../services/companyService'

export const COMPANIES_GETALL_BEGIN = 'COMPANIES_GETALL_BEGIN'
export const COMPANIES_GETALL_SUCCESS = 'COMPANIES_GETALL_SUCCESS'
export const COMPANIES_GETALL_FAILURE = 'COMPANIES_GETALL_FAILURE'
export const COMPANY_CREATE_BEGIN = 'COMPANIES_CREATE_BEGIN'
export const COMPANY_CREATE_SUCCESS = 'COMPANY_CREATE_SUCCESS'
export const COMPANY_CREATE_FAILURE = 'COMPANY_CREATE_FAILURE'

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

const addCompanyBegin = () => ({
  type: COMPANY_CREATE_BEGIN
})

const addCompanySuccess = company => ({
  type: COMPANY_CREATE_SUCCESS,
  payload: { company }
})

const addCompanyFailure = error => ({
  type: COMPANY_CREATE_FAILURE,
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

export const addCompany = company => {
  return async (dispatch) => {
    dispatch(addCompanyBegin())
    try {
      const company = await companiesService.addCompany()
      dispatch(addCompanySuccess(company))
    } catch (error) {
      console.log(error)
      dispatch(addCompanyFailure(error))
    }
  }
}