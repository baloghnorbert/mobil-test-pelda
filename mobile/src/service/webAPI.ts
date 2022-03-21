import { baseURL } from "./base.url";
import { FetchProxy } from "./fetch.proxy";
import { StorageService } from "./../storage/storage.service";
import {
    PlayerService,
    FileUploadService,
    PositionService,
    SecurityService
} from "./wrappers";

export namespace WebAPI
{
    const storageService: StorageService = new StorageService();

    const proxy: FetchProxy = new FetchProxy();
    proxy.bearerToken = getToken()!;

    const signOutCallback: (() => void) | null = null;

    export const Security: SecurityService = new SecurityService(baseURL, proxy);
    export const Players: PlayerService = new PlayerService(baseURL, proxy);
    export const Positions: PositionService = new PositionService(baseURL, proxy);
    export const Files: FileUploadService = new FileUploadService(baseURL, proxy);


    export function attachToConnectionCallback(callback: (res: Response) => void)
    {
        proxy.attachToConnectionCallback(callback);
    }

    export function clearConnectionCallback()
    {
        proxy.clearConnectionCallback();
    }

    export function IsTokenAssigned(): boolean
    {
        const token = getToken();
        return token != null && token !== undefined;
    }

    export function getToken(): string | null
    {
        const token: string | null = storageService.get("amazons.volleyball.com");
        return token;
    }

    export async function setToken(value: string | undefined): Promise<void>
    {
        storageService.set("amazons.volleyball.com", value);
        proxy.bearerToken = value;
    }

    export function removeToken(): void
    {
        storageService.remove("amazons.volleyball.com");
        proxy.bearerToken = undefined;
    }
}
