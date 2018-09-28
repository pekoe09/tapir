import React from 'react'
import TapirSidebar from './TapirSidebar'
import TapirNavbar from './TapirNavbar'

const TapirLayout = (props) => {
  return (
    <div style={{ display: 'flex', height: '100vh', fontFamily: 'Open sans' }}>
      <TapirSidebar />
      <div id='main'>
        <TapirNavbar />
        {props.children}
      </div>
    </div>
  )
}
    
export default TapirLayout