import { useContext } from "react"
import { GlobalContext } from "../context/GlobalState"

const Content = () => {
    //test variables
    const name = "franz wurm"
    const puuid = "fQZrF05nFdYIyK98aMj-bF02uD6CkcE7bLes_GEuux0BCzXZ-X2PUOZyojQ8Tttvm0QCnCOMcRr7Ew"
    const region = "eune"

    const { getSummoner, getMatches, updateSummoner, summoner, matches, page } = useContext(GlobalContext);

    const getSummonerClick = async () => {
    const summoner = await getSummoner?.({name, region})
    console.log(summoner)
    }

    const updateClick = async () => {
    const summoner = await updateSummoner?.({puuid, region})
    console.log(summoner)
    }

    const getMatchesClick = async () => {
    const summoner = await getMatches?.({name, region, pageNumber: page})
    console.log(summoner)
    }

    return(
        <>
            <button onClick={getSummonerClick}>getSummoner</button>
            <button onClick={updateClick}>update</button>
            <button onClick={getMatchesClick}>getMatches</button>
            <ul>
                {matches.map(m => (<li key={m.matchId} >{m.matchId}</li>))}
            </ul>
            <h1>Summoner: {summoner?.name}</h1>
        </>
    )
}

export default Content
