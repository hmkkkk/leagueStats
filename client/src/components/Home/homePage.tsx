import HomePageForm from "./homePageForm";

const HomePage = () => {
    return (
        <div className="container mt-4" style={{width: "40%"}}>
            <div className="text-center">
                <h1>League Stats</h1>
            </div>
            <div className="">
                <HomePageForm />
            </div>
        </div>
    )
}

export default HomePage;