import {
  EMPLOYMENTS_GETALL_BEGIN,
  EMPLOYMENTS_GETALL_SUCCESS,
  EMPLOYMENTS_GETALL_FAILURE,
  EMPLOYMENT_CREATE_BEGIN,
  EMPLOYMENT_CREATE_SUCCESS,
  EMPLOYMENT_CREATE_FAILURE,
  EMPLOYMENT_UPDATE_BEGIN,
  EMPLOYMENT_UPDATE_SUCCESS,
  EMPLOYMENT_UDPATE_FAILURE,
  EMPLOYMENT_DELETE_BEGIN,
  EMPLOYMENT_DELETE_SUCCESS,
  EMPLOYMENT_DELETE_FAILURE
} from '../actions/employmentActions'

const initialState = {
  items: [],
  loading: false,
  creating: false,
  updating: false,
  deleting: false,
  error: null
}

const employmentReducer = (store = initialState, action) => {
  switch (action.type) {
    case EMPLOYMENTS_GETALL_BEGIN:
      return {
        ...store,
        loading: true,
        error: null
      }
    case EMPLOYMENTS_GETALL_SUCCESS:
      return {
        ...store,
        items: action.payload.employments,
        loading: false,
        error: null
      }
    case EMPLOYMENTS_GETALL_FAILURE:
      return {
        ...store,
        loading: false,
        error: action.payload.error
      }
    case EMPLOYMENT_CREATE_BEGIN:
      return {
        ...store,
        creating: true,
        error: null
      }
    case EMPLOYMENT_CREATE_SUCCESS:
      return {
        ...store,
        items: store.items.concat(action.payload.employment),
        creating: false,
        error: null
      }
    case EMPLOYMENT_CREATE_FAILURE:
      return {
        ...store,
        creating: false,
        error: action.payload.error
      }
    case EMPLOYMENT_UPDATE_BEGIN:
      return {
        ...store,
        updating: true,
        error: null
      }
    case EMPLOYMENT_UPDATE_SUCCESS:
      const updated = action.payload.employment
      return {
        ...store,
        items: store.items.map(p => p.id === updated.id ? updated : p),
        updating: false,
        error: null
      }
    case EMPLOYMENT_UDPATE_FAILURE:
      return {
        ...store,
        updating: false,
        error: action.payload.error
      }
    case EMPLOYMENT_DELETE_BEGIN:
      return {
        ...store,
        deleting: true,
        error: null
      }
    case EMPLOYMENT_DELETE_SUCCESS:
      return {
        ...store,
        items: store.items.filter(p => p.id !== action.payload.employment.id),
        deleting: false,
        error: null
      }
    case EMPLOYMENT_DELETE_FAILURE:
      return {
        ...store,
        deleting: false,
        error: action.payload.error
      }
    default:
      return store
  }
}

export default employmentReducer