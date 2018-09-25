import React from 'react'
import TapirSidebar from './TapirSidebar'

const TapirLayout = (props) => {
  return (
    <div style={{ display: 'flex', height: '100vh' }}>
      <TapirSidebar />
      <div id='main'>
        <h1>Tapir layout</h1>
        {props.children}
      </div>
    </div>
  )
}
    
export default TapirLayout