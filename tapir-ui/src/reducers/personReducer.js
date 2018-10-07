import {
  PERSONS_GETALL_BEGIN,
  PERSONS_GETALL_SUCCESS,
  PERSONS_GETALL_FAILURE,
  PERSON_CREATE_BEGIN,
  PERSON_CREATE_SUCCESS,
  PERSON_CREATE_FAILURE,
  PERSON_UPDATE_BEGIN,
  PERSON_UPDATE_SUCCESS,
  PERSON_UDPATE_FAILURE,
  PERSON_DELETE_BEGIN,
  PERSON_DELETE_SUCCESS,
  PERSON_DELETE_FAILURE
} from '../actions/personActions'

const initialState = {
  items: [],
  loading: false,
  creating: false,
  updating: false,
  deleting: false,
  error: null
}

const personReducer = (store = initialState, action) => {
  switch (action.type) {
    case PERSONS_GETALL_BEGIN:
      return {
        ...store,
        loading: true,
        error: null
      }
    case PERSONS_GETALL_SUCCESS:
      return {
        ...store,
        items: action.payload.persons,
        loading: false,
        error: null
      }
    case PERSONS_GETALL_FAILURE:
      return {
        ...store,
        loading: false,
        error: action.payload.error
      }
    case PERSON_CREATE_BEGIN:
      return {
        ...store,
        creating: true,
        error: null
      }
    case PERSON_CREATE_SUCCESS:
      return {
        ...store,
        items: store.items.concat(action.payload.person),
        creating: false,
        error: null
      }
    case PERSON_CREATE_FAILURE:
      return {
        ...store,
        creating: false,
        error: action.payload.error
      }
    case PERSON_UPDATE_BEGIN:
      return {
        ...store,
        updating: true,
        error: null
      }
    case PERSON_UPDATE_SUCCESS:
      const updated = action.payload.person
      return {
        ...store,
        items: store.items.map(p => p.id === updated.id ? updated : p),
        updating: false,
        error: null
      }
    case PERSON_UDPATE_FAILURE:
      return {
        ...store,
        updating: false,
        error: action.payload.error
      }
    case PERSON_DELETE_BEGIN:
      return {
        ...store,
        deleting: true,
        error: null
      }
    case PERSON_DELETE_SUCCESS:
      return {
        ...store,
        items: store.items.filter(p => p.id !== action.payload.person.id),
        deleting: false,
        error: null
      }
    case PERSON_DELETE_FAILURE:
      return {
        ...store,
        deleting: false,
        error: action.payload.error
      }
    default:
      return store
  }
}

export default personReducer