import {
  SECTORS_GETALL_BEGIN,
  SECTORS_GETALL_SUCCESS,
  SECTORS_GETALL_FAILURE
} from '../actions/sectorActions'

const initialState = {
  items: [],
  loading: false,
  error: null
}

const sectorReducer = (store = initialState, action) => {
  switch (action.type) {
    case SECTORS_GETALL_BEGIN:
      return {
        ...store,
        loading: true,
        error: null
      }
    case SECTORS_GETALL_SUCCESS:
      return {
        ...store,
        items: action.payload.sectors,
        loading: false,
        error: null
      }
    case SECTORS_GETALL_FAILURE:
      return {
        ...store,
        loading: false,
        error: action.payload.error
      }
    default:
      return store
  }
}

export default sectorReducer