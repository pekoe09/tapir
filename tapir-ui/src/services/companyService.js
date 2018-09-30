import axios from 'axios'

const baseUrl = '/api/companies'

const getAll = async () => {
  const response = await axios.get(baseUrl)
  return response.data
}

const addCompany = async (company) => {
  const response = await axios.post(baseUrl, company)
  return response.data
}

const updateCompany = async (company) => {
  console.log('Updating company', company)
  const response = await axios.put(`${baseUrl}/${company.id}`, company)
  console.log('got response', response)
  return response.data
}

const removeCompany = async (id) => {
  const response = await axios.delete(`${baseUrl}/${id}`)
  return response.data
}

export default {
  getAll,
  addCompany,
  updateCompany,
  removeCompany
}