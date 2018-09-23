import {
  COMPANIES_GETALL_BEGIN,
  COMPANIES_GETALL_SUCCESS,
  COMPANIES_GETALL_FAILURE
} from '../actions/companyActions'

const initialState = {
  items: [],
  loading: false,
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
    default:
      return store
  }
}

export default companyReducer