const Select = ({name, value, classList, options, onChange = (event) => {}, label = "", required = false}) => {
    const labelNode = label ? <label className="form-label">{label}</label> : <></>

    return (
        <>
            {labelNode}
            <select required={required} name={name} value={value} className={classList.join(" ")} onChange={onChange}>
                {options.map(option => <option key={option.value} value={option.value}>{option.text}</option>)}
            </select>
        </>
    )
}

export default Select;