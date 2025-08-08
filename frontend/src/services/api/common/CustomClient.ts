import { tsRestFetchApi, type ApiFetcherArgs } from "@ts-rest/core";

export interface CustomTsRestClientArgs extends ApiFetcherArgs {
    silent?: boolean;
    toastHttpOverride?: "GET" | "POST" | "DELETE";
    extraInfo?: string;
}

export const customTsRestClient = async (args: CustomTsRestClientArgs) => {
    const 


}