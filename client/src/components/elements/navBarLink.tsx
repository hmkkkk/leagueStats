import { NavLink } from "react-router-dom"

const NavBarLink = ({name, route, classlist}) => {
    return (
        <>
            <NavLink className={({ isActive }) => [
                ...classlist,
                isActive ? "linkActive" : ""].join(" ")} to={route}>
                    {name}
            </NavLink>
        </>
    )
}

export default NavBarLink;
