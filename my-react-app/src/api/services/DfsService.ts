/* generated using openapi-typescript-codegen -- do not edit */
/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { MazeInputDto } from '../models/MazeInputDto';
import type { MazeModelDto } from '../models/MazeModelDto';
import type { CancelablePromise } from '../core/CancelablePromise';
import { OpenAPI } from '../core/OpenAPI';
import { request as __request } from '../core/request';
export class DfsService {
    /**
     * @param requestBody
     * @returns MazeModelDto OK
     * @throws ApiError
     */
    public static postDfsConvert(
        requestBody?: Array<Array<number>>,
    ): CancelablePromise<MazeModelDto> {
        return __request(OpenAPI, {
            method: 'POST',
            url: '/DFS/convert',
            body: requestBody,
            mediaType: 'application/json',
        });
    }
    /**
     * @param requestBody
     * @returns MazeModelDto OK
     * @throws ApiError
     */
    public static postDfsSolve(
        requestBody?: MazeInputDto,
    ): CancelablePromise<MazeModelDto> {
        return __request(OpenAPI, {
            method: 'POST',
            url: '/DFS/solve',
            body: requestBody,
            mediaType: 'application/json',
        });
    }
}
