import React from 'react'
import { connect } from 'react-redux'
import { Alert } from 'react-bootstrap'

const getAlerts = (messages) => {
  console.log('Mapping to alerts')
  return messages.map(m =>
    <Alert bsStyle={m.type} key={m.timestamp + m.content}>{m.content} {m.timestamp + ' '}</Alert>  
  )
}

const TapirMessages = ({ messages }) => {
  console.log('found messages: ', messages)
  return (
    <div>
      {messages ? getAlerts(messages) : ''}
    </div>
  )
}

const mapStateToProps = store => {
  console.log('Getting messages', store.uiMessages.items)
  return {
    messages: store.uiMessages.items
  }
}

export default connect(
  mapStateToProps
)(TapirMessages)