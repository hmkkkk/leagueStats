import axios from 'axios'
import { Summoner } from '../models/entities/Summoner'
import { SummonerForm } from '../models/forms/SummonerForm'
import { SummonerUpdateForm } from '../models/forms/summonerUpdateForm'

const baseUrl = import.meta.env.VITE_BASEURL

export const getSummonerByNameAndRegion = async (form: SummonerForm) => {
    const response = await axios.get<Summoner>(baseUrl + `/summoners/${form.region}/${form.name}`)
    console.log(response.data, "getSummonerByNameAndRegion")
    return response.data
}

export const updateSummonerProfile = async (form: SummonerUpdateForm) => {
    const response = await axios.get<Summoner>(baseUrl + `/summoners/${form.region}/${form.puuid}/update`)
    console.log(response.data, "updateSummonerProfile")
    return response.data
}
