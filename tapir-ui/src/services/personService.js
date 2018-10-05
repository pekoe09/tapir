import axios from 'axios'

const baseUrl = '/api/persons'

const getAll = async () => {
  const response = await axios.get(baseUrl)
  return response.data
}

const addPerson = async (person) => {
  const response = await axios.post(baseUrl, person)
  return response.data
}

const updatePerson = async (person) => {
  const response = await axios.put(`${baseUrl}/${person.id}`, person)
  return response.data
}

const removePerson = async (id) => {
  const response = await axios.delete(`${baseUrl}/${id}`)
  return response.data
}

export default {
  getAll,
  addPerson,
  updatePerson,
  removePerson
}