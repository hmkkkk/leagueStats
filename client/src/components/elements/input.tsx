const Input = ({name, value, type, classList, onChange = (event) => {}, label = "", required = false}) => {
    const labelNode = label ? <label className="form-label">{label}</label> : <></>

    return (
        <>
            {labelNode}
            <input required={required} name={name} value={value} type={type} className={classList.join(" ")} onChange={onChange}></input>
        </>
    )
}

export default Input;


{/* <div class="input-group mb-3">
  <button class="btn btn-outline-secondary dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-expanded="false">Dropdown</button>
  <ul class="dropdown-menu">
    <li><a class="dropdown-item" href="#">Action</a></li>
    <li><a class="dropdown-item" href="#">Another action</a></li>
    <li><a class="dropdown-item" href="#">Something else here</a></li>
    <li><hr class="dropdown-divider"></li>
    <li><a class="dropdown-item" href="#">Separated link</a></li>
  </ul>
  <input type="text" class="form-control" aria-label="Text input with dropdown button">
</div> */}