import {
  COMPANIES_GETALL_BEGIN,
  COMPANIES_GETALL_SUCCESS,
  COMPANIES_GETALL_FAILURE,
  COMPANY_CREATE_BEGIN,
  COMPANY_CREATE_SUCCESS,
  COMPANY_CREATE_FAILURE
} from '../actions/companyActions'

const initialState = {
  items: [],
  loading: false,
  creating: false,
  error: null
}

const companyReducer = (store = initialState, action) => {
  switch (action.type) {
    case COMPANIES_GETALL_BEGIN:
      return {
        ...store,
        loading: true,
        error: null
      }
    case COMPANIES_GETALL_SUCCESS:
      return {
        ...store,
        items: action.payload.companies,
        loading: false,
        error: null
      }
    case COMPANIES_GETALL_FAILURE:
      return {
        ...store,
        loading: false,
        error: action.payload.error
      }
    case COMPANY_CREATE_BEGIN:
      return {
        ...store,
        creating: true,
        error: null
      }
    case COMPANY_CREATE_SUCCESS:
      return {
        ...store,
        items: store.items.concat(action.payload.company),
        creating: false,
        error: null
      }
    case COMPANY_CREATE_FAILURE:
      return {
        ...store,
        creating: false,
        error: action.payload.error
      }
    default:
      return store
  }
}

export default companyReducer