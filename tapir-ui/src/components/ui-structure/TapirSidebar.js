import React from 'react'
import { Link } from 'react-router-dom'
import Sidebar from 'grommet/components/Sidebar'
import Header from 'grommet/components/Header'
import Title from 'grommet/components/Title'
import Menu from 'grommet/components/Menu'
import Anchor from 'grommet/components/Anchor'
import Box from 'grommet/components/Box'

const TapirSidebar = () => {
  return (
    <Sidebar colorIndex='neutral-1'>
      <Header pad='medium'>
        <Title>
          Tapiiri
        </Title>
      </Header>
      <Box flex='grow' justify='start'>
        <Menu primary={true}>
          <Link to='/companies' className='grommetux-anchor'>
            Companies
          </Link>
          <Link to='/persons' className='grommetux-anchor'>
            Persons
          </Link>
          <Link to='/employments' className='grommetux-anchor'>
            Employments
          </Link>
        </Menu>
      </Box>
    </Sidebar>
  )
}

export default TapirSidebar