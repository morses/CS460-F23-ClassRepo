import type { RequestHandler } from './$types';
import { fail, json } from '@sveltejs/kit';
import { TmdbBearerToken } from '$env/static/private';

// Exported GET, POST, PUT, DELETE, etc. functions create API endpoints for this route
// This is like an APIController in MVC

// Helper function is duplicated, could move to a lib folder
async function fetchMovieDetails(id: number) {
    console.log('token:', TmdbBearerToken);
    const uri = `https://api.themoviedb.org/3/movie/${id}?language=en-US`;
    // fetch this uri and set headers
    const response = await fetch(uri, {
        headers: {
            Authorization: `Bearer ${TmdbBearerToken}`,
            Accept: 'application/json'
        }
    });
    const data = await response.json();
    // Needs error handling here
    return data;
}

export const POST: RequestHandler = async ({ request }) => {
    const { id } = await request.json();
    if (!id)
        return fail(400, { id: id, missing: true });
    const data = await fetchMovieDetails(id);
    return json({ id: id, success: true, data: data});
}