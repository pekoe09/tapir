import axios from 'axios'

const baseUrl = '/api/employments'

const getAll = async () => {
  const response = await axios.get(baseUrl)
  return response.data
}

const addEmployment = async (employment) => {
  const response = await axios.post(baseUrl, employment)
  return response.data
}

const updateEmployment = async (employment) => {
  const response = await axios.put(`${baseUrl}/${employment.id}`, employment)
  return response.data
}

const removeEmployment = async (id) => {
  const response = await axios.delete(`${baseUrl}/${id}`)
  return response.data
}

export default {
  getAll,
  addEmployment,
  updateEmployment,
  removeEmployment
}