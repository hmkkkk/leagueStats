import axios from 'axios'
import { Summoner } from '../models/Summoner'
import { GetSummonerForm } from '../models/GetSummonerForm'

const baseUrl = import.meta.env.VITE_BASEURL

export const getSummonerByNameAndRegion = async (form: GetSummonerForm) => {
    const response = await axios.get<Summoner>(baseUrl + `/summoners/${form.region}/${form.name}`)
    return response.data
}

export const updateSummoner = async (form: GetSummonerForm) => {
    const response = await axios.get<Summoner>(baseUrl + `/summoners/${form.region}/${form.name}/update`)
    return response.data
}
