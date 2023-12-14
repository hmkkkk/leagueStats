import { createContext, useReducer } from "react"
import AppReducer from "./AppReducer"
import { getSummonerByNameAndRegion, updateSummonerProfile } from "../services/summonerService"
import { getSummonerMatches } from "../services/matchService"
import { SummonerForm } from "../models/forms/SummonerForm"
import { SummonerUpdateForm } from "../models/forms/summonerUpdateForm"
import { MatchForm } from "../models/forms/MatchForm"
import { Summoner } from "../models/entities/Summoner"
import { Match } from "../models/entities/Match"

interface Istate {
    matches: Match[],
    summoner?: Summoner,
    page: number,
    error?: string,
    getSummoner?: (form: SummonerForm) => Promise<void>;
    updateSummoner?: (form: SummonerUpdateForm) => Promise<void>;
    getMatches?: (form: MatchForm) => Promise<void>;
}

const initialState: Istate = {
    matches: [],
    summoner: undefined,
    page: 1,
    error: undefined,
}

export const GlobalContext = createContext(initialState)

export const GlobalProvider = ({ children }) => {
    const [state, dispatch] = useReducer(AppReducer, initialState)

    const getSummoner = async (form: SummonerForm): Promise<void> =>{
        try {
            const response = await getSummonerByNameAndRegion(form)
            dispatch({
                type: 'GET_USER',
                payload: response
            })
        } catch (error: any) {
            dispatch({
                type: 'ERROR',
                payload: error.response.data.error
            })
        }
    }

    const updateSummoner = async (form: SummonerUpdateForm): Promise<void> =>{
        try {
            const response = await updateSummonerProfile(form)
            dispatch({
                type: 'UPDATE_USER',
                payload: response
            })
        } catch (error: any) {
            dispatch({
                type: 'ERROR',
                payload: error.response.data.error
            })
        }
    }

    const getMatches = async (form: MatchForm): Promise<void> =>{
        try {
            const response = await getSummonerMatches(form)
            dispatch({
                type: 'GET_MATCHES',
                payload: response
            })
        } catch (error: any) {
            dispatch({
                type: 'ERROR',
                payload: error.response.data.error
            })
        }
    }

    return (<GlobalContext.Provider value={{
        matches: state.matches,
        error: state.error,
        page: state.page,
        summoner: state.summoner,
        getSummoner,
        updateSummoner,
        getMatches
    }}>
        {children}
    </GlobalContext.Provider>);
}