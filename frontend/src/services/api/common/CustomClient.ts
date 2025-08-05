import { tsRestFetchApi, type ApiFetcherArgs } from "@ts-rest/core";

export interface CustomTsRestClientArgs extends ApiFetcherArgs {
    silent?: boolean;
    toastHttpOverride?: "GET" | "POST" | "DELETE";
    extraInfo?: string;
}

export const customTsRestClient = async (args: CustomTsRestClientArgs) => {
    if (args.silent) {
        return tsRestFetchApi(args);
    }

    const response = await tsRestFetchApi(args);
    const id = args.path;
    const requestId = args.path.split("/").pop() || "";
}