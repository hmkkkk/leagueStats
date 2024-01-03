import NavBarLink from "../elements/navBarLink"
import './navBar.css'

const NavBar = () => {
    return (
        <div className="navbar navbar-expand-lg d-flex justify-content-center">
            <NavBarLink name={'Home'} route={'/'} classList={['navLink']} />
            <NavBarLink name={'Test page'} route={'/testPage'} classList={['navLink']} />
            <NavBarLink name={'summoner page'} route={'/eune/franz wurm'} classList={['navLink']} />
        </div>
    )
}


export default NavBar