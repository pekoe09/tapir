import React from 'react'
import Split from 'grommet/components/Split'
import Animate from 'grommet/components/Animate'
import TapirSidebar from './TapirSidebar'
import Article from 'grommet/components/Article'

const TapirLayout = (props) => {
  return (
    <Split>
      <Animate
        enter={{ "animation": "slide-right", "duration": 500 }}
        leave={{ "animation": "slide-left", "duration": 500 }}
        visible={true}
      >
        <TapirSidebar />
      </Animate>
      <Article>
        {props.children}
      </Article>
    </Split>
  )
}
    
export default TapirLayout