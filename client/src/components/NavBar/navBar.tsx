import NavBarLink from "../elements/navBarLink"
import './navBar.css'

const NavBar = () => {
    return (
        <>
            <NavBarLink name={'Home'} route={'/'} classlist={['navLink']} />
            <NavBarLink name={'Test page'} route={'/testPage'} classlist={['navLink']} />
            <NavBarLink name={'summoner page'} route={'/eune/franz wurm'} classlist={['navLink']} />
        </>
    )
}


export default NavBar