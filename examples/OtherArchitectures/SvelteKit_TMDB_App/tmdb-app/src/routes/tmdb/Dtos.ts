// Define types for the objects we receive from the TMDB API
// I've been wondering what a good solution was for correctly handling JSON data from an API.
// Now that I'm using TypeScript and Node.js I thought I'd look for a solution using a 3rd party library.
// Trying out Zod: https://zod.dev/
// Looking for an easy way to define types, and then to run validation on the data we receive.

// Using https://transform.tools/json-to-zod to easily generate the schema from an example JSON object

import { z } from 'zod';

/* List of movies returned from a search at /search/movie?query= */

const MovieOverviewSchema = z.object({
    adult: z.boolean(),
    backdrop_path: z.string().nullable(),
    genre_ids: z.array(z.number()),
    id: z.number(),
    original_language: z.string(),
    original_title: z.string(),
    overview: z.string(),
    popularity: z.number(),
    poster_path: z.string().nullable(),
    release_date: z.string(),
    title: z.string(),
    video: z.boolean(),
    vote_average: z.number(),
    vote_count: z.number()
});

const MovieSearchResultsSchema = z.object({
    page: z.number(),
    results: z.array(MovieOverviewSchema),
    total_pages: z.number(),
    total_results: z.number()
});

/* Movie details returned from /movie/{id} */

export const MovieDetailsSchema = z.object({
    adult: z.boolean(),
    backdrop_path: z.string(),
    belongs_to_collection: z.nullable(z.object({
        id: z.number(),
        name: z.string(),
        poster_path: z.string(),
        backdrop_path: z.string()
    })),
    budget: z.number(),
    genres: z.array(
        z.object({
            id: z.number(),
            name: z.string()
        })),
    homepage: z.string(),
    id: z.number(),
    imdb_id: z.string(),
    origin_country: z.array(z.string()),
    original_language: z.string(),
    original_title: z.string(),
    overview: z.string(),
    popularity: z.number(),
    poster_path: z.string(),
    production_companies: z.array(
        z.object({
            id: z.number(),
            logo_path: z.string().nullable(),
            name: z.string(),
            origin_country: z.string()
        })
    ).nullable(),
    production_countries: z.array(
        z.object({
            iso_3166_1: z.string(),
            name: z.string()
        })
    ).nullable(),
    release_date: z.string(),
    revenue: z.number(),
    runtime: z.number(),
    spoken_languages: z.array(
        z.object({
            english_name: z.string(),
            iso_639_1: z.string(),
            name: z.string()
        })
    ).nullable(),
    status: z.string(),
    tagline: z.string(),
    title: z.string(),
    video: z.boolean(),
    vote_average: z.number(),
    vote_count: z.number()
});

export type MovieOverview = z.infer<typeof MovieOverviewSchema>;
export type MovieSearchResults = z.infer<typeof MovieSearchResultsSchema>;
export type MovieDetails = z.infer<typeof MovieDetailsSchema>;

/* Throws a ZodError if it fails validation */
export function parseMovieSearchResults(data: unknown): MovieSearchResults {
    return MovieSearchResultsSchema.parse(data);
}

export function parseMovieDetails(data: unknown): MovieDetails {
    return MovieDetailsSchema.parse(data);
}