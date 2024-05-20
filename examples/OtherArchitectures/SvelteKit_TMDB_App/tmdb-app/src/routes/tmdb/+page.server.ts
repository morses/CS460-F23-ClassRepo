import {API_KEY } from '$env/static/private'

export const load = ( { fetch, params } ) => {
    return {
        movies: fetch(`https://api.themoviedb.org/3/movie/popular?api_key=${API_KEY}&language=en-US&page=${params.page}`)
        .then( res => res.json() )
    }
}