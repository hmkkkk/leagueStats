import { NavLink } from "react-router-dom"

const NavBarLink = ({name, route, classList}) => {
    return (
        <>
            <NavLink className={({ isActive }) => [
                ...classList,
                isActive ? "linkActive" : ""].join(" ")} to={route}>
                    {name}
            </NavLink>
        </>
    )
}

export default NavBarLink;
