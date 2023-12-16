import { useParams } from "react-router-dom";

const SummonerPage = () => {
    const params = useParams()
    return (
        <>
            <h1>Summoner page!</h1>
            <p>name: {params.name}</p>
            <p>region: {params.region}</p>
        </>
    )
}

export default SummonerPage;