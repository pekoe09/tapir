import React from 'react'
import TapirSidebar from './TapirSidebar'
import TapirNavbar from './TapirNavbar'
import TapirMessages from './TapirMessages'

const TapirLayout = (props) => {
  return (
    <div style={{ display: 'flex', height: 'fit-content', fontFamily: 'Open sans' }}>
      <TapirSidebar />
      <div id='main'>
        <TapirNavbar />
        <TapirMessages />
        {props.children}
      </div>
    </div>
  )
}
    
export default TapirLayout