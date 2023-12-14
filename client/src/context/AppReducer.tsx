const AppReducer = (state: any, action: any) => {
    switch (action.type) {
        case 'GET_USER':
        case 'UPDATE_USER':
            return {
                ...state,
                summoner: action.payload
            }
        case 'GET_MATCHES':
            return {
                ...state,
                page: state.page + 1,
                matches: state.matches.concat(action.payload)
            }
        case 'ERROR':
            return {
                ...state,
                error: action.payload
            }
        default:
            return state;
    }
}

export default AppReducer