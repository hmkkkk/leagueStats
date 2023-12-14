import axios from 'axios'
import { MatchForm } from '../models/forms/MatchForm'
import { Match } from '../models/entities/Match'

const baseUrl = import.meta.env.VITE_BASEURL

export const getSummonerMatches = async (form: MatchForm) => {
    const response = await axios.get<Match>(baseUrl + `/matches/${form.region}/${form.name}?pageNumber=${form.pageNumber}`)
    console.log(form.pageNumber, "page")
    console.log(response.data, "getSummonerMatches")
    return response.data
}