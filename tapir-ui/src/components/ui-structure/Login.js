import React from 'react'
import { connect } from 'react-redux'
import { Navbar, FormGroup, FormControl, Button, ControlLabel } from 'react-bootstrap'
import { login } from '../../actions/authActions'

class Login extends React.Component {

  constructor(props) {
    super(props)
    this.state = {
      username: '',
      password: ''
    }
  }

  handleChange = (event) => {
    this.setState({ [event.target.name]: event.target.value })
  }

  handleSubmit = async (event) => {
    event.preventDefault
    const credentials = {
      username: this.state.username,
      password: this.state.password
    }
    await this.props.login(credentials)
  }

  render() {
    return (
      <div>
        <FormGroup>
          <ControlLabel>Username</ControlLabel>
          <FormControl
            type='text'
            name='username'
            value={this.state.username}
            onChange={this.handleChange}
          />
        </FormGroup>
        <FormGroup>
          <ControlLabel>Password</ControlLabel>
          <FormControl
            type='password'
            name='password'
            value={this.state.password}
            onChange={this.handleChange}
          />
        </FormGroup>
        <Button
          onClick={this.handleSubmit}
        >
          Login
        </Button>
      </div>
    )
  }
}

export default connect(
  null,
  {
    login
  }
)(Login)