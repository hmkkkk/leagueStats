import { Outlet } from "react-router-dom";
import NavBar from "./NavBar/navBar"

const Root = () => {
    return (
        <>
            <NavBar />
            <div id="pageContent">
                <Outlet />
            </div>
        </>
    )
}

export default Root;