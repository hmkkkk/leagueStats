import { useNavigate } from "react-router-dom"
import { useState } from "react"
import Input from "../elements/input"
import Select from "../elements/select"
import regionsArray from "../../Helpers/Constants/RegionConstants"
import { SelectListValue } from "../../models/forms/SelectListValue"

const HomePageForm = () => {
    const navigate = useNavigate()
    const [region, setRegion] = useState("eune")
    const [searchName, setSearchName] = useState("")

    const options: SelectListValue[] = regionsArray.map(x => {
        return {
            value: x,
            text: x.toLocaleUpperCase()
        } 
    })

    const submitSearchForm = (event) => {
        event.preventDefault()
        if (region && searchName) {
            navigate(`${region}/${searchName}`)
        }
    }

    return (
        <form name="searchForm" onSubmit={submitSearchForm}>
            <div className="input-group form-row">
                <Select required={true} name="region" value={region} classList={['input-group-text']} options={options} onChange={(e) => setRegion(e.target.value)} />
                <Input required={true} name="searchName" value={searchName} type="text" classList={['form-control']} onChange={(e) => setSearchName(e.target.value)} />
                <button type="submit" className="btn btn-outline-secondary">
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" className="bi bi-search" viewBox="0 0 16 16">
                        <path d="M11.742 10.344a6.5 6.5 0 1 0-1.397 1.398h-.001q.044.06.098.115l3.85 3.85a1 1 0 0 0 1.415-1.414l-3.85-3.85a1 1 0 0 0-.115-.1zM12 6.5a5.5 5.5 0 1 1-11 0 5.5 5.5 0 0 1 11 0"></path>
                    </svg>
                </button>
            </div>
        </form>
    )
}

export default HomePageForm