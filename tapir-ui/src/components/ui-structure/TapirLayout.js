import React from 'react'
import Split from 'grommet/components/Split'
import Sidebar from 'grommet/components/Sidebar'
import Article from 'grommet/components/Article'

const TapirLayout = () => {
    return (
        <Split>
            <Sidebar>
                sivupalkkia
            </Sidebar>
            <Article>
                artikkelia
            </Article>
        </Split>
    )
}

export default TapirLayout