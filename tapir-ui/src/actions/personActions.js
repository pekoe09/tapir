import personService from '../services/personService'

export const PERSONS_GETALL_BEGIN = 'PERSONS_GETALL_BEGIN'
export const PERSONS_GETALL_SUCCESS = 'PERSONS_GETALL_SUCCESS'
export const PERSONS_GETALL_FAILURE = 'PERSONS_GETALL_FAILURE'
export const PERSON_CREATE_BEGIN = 'PERSON_CREATE_BEGIN'
export const PERSON_CREATE_SUCCESS = 'PERSON_CREATE_SUCCESS'
export const PERSON_CREATE_FAILURE = 'PERSON_CREATE_FAILURE'
export const PERSON_UPDATE_BEGIN = 'PERSON_UPDATE_BEGIN'
export const PERSON_UPDATE_SUCCESS = 'PERSON_UPDATE_SUCCESS'
export const PERSON_UDPATE_FAILURE = 'PERSON_UPDATE_FAILURE'
export const PERSON_DELETE_BEGIN = 'PERSON_DELETE_BEGIN'
export const PERSON_DELETE_SUCCESS = 'PERSON_DELETE_SUCCESS'
export const PERSON_DELETE_FAILURE = 'PERSON_DELETE_FAILURE'

const getAllPersonsBegin = () => ({
  type: PERSONS_GETALL_BEGIN
})

const getAllPersonsSuccess = persons => ({
  type: PERSONS_GETALL_SUCCESS,
  payload: { persons }
})

const getAllPersonsFailure = error => ({
  type: PERSONS_GETALL_FAILURE,
  payload: { error }
})

const addPersonBegin = () => ({
  type: PERSON_CREATE_BEGIN
})

const addPersonSuccess = person => ({
  type: PERSON_CREATE_SUCCESS,
  payload: { person }
})

const addPersonFailure = error => ({
  type: PERSON_CREATE_FAILURE,
  payload: { error }
})

const updatePersonBegin = () => ({
  type: PERSON_UPDATE_BEGIN
})

const updatePersonSuccess = person => ({
  type: PERSON_UPDATE_SUCCESS,
  payload: { person }
})

const updatePersonFailure = error => ({
  type: PERSON_UDPATE_FAILURE,
  payload: { error }
})

const deletePersonBegin = () => ({
  type: PERSON_DELETE_BEGIN
})

const deletePersonSuccess = person => ({
  type: PERSON_DELETE_SUCCESS,
  payload: { person }
})

const deletePersonFailure = error => ({
  type: PERSON_DELETE_FAILURE,
  payload: { error }
})

export const getAllPersons = () => {
  return async (dispatch) => {
    dispatch(getAllPersonsBegin())
    try {
      const persons = await personService.getAll()
      dispatch(getAllPersonsSuccess(persons))
    } catch (error) {
      console.log(error)
      dispatch(getAllPersonsFailure(error))
    }
  }
}

export const addPerson = (person) => {
  return async (dispatch) => {
    dispatch(addPersonBegin())
    try {
      person = await personService.addPerson(person)
      dispatch(addPersonSuccess(person))
    } catch (error) {
      console.log(error)
      dispatch(addPersonFailure(error))
    }
  }
}

export const updatePerson = (person) => {
  return async (dispatch) => {
    dispatch(updatePersonBegin())
    try {
      person = await personService.updatePerson(person)
      dispatch(updatePersonSuccess(person))
    } catch (error) {
      console.log(error)
      dispatch(updatePersonFailure(error))
    }
  }
}

export const deletePerson = (id) => {
  return async (dispatch) => {
    dispatch(deletePersonBegin())
    try {
      const person = await personService.removePerson(id)
      dispatch(deletePersonSuccess(person))
    } catch (error) {
      console.log(error)
      dispatch(deletePersonFailure(error))
    }
  }
}