/* generated using openapi-typescript-codegen -- do not edit */
/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { MazeModelDto } from '../models/MazeModelDto';
import type { SolveMazeResultDto } from '../models/SolveMazeResultDto';
import type { CancelablePromise } from '../core/CancelablePromise';
import { OpenAPI } from '../core/OpenAPI';
import { request as __request } from '../core/request';
export class GreedyService {
    /**
     * @param requestBody
     * @returns MazeModelDto OK
     * @throws ApiError
     */
    public static postConvert(
        requestBody?: Array<Array<number>>,
    ): CancelablePromise<MazeModelDto> {
        return __request(OpenAPI, {
            method: 'POST',
            url: '/convert',
            body: requestBody,
            mediaType: 'application/json',
        });
    }
    /**
     * @param requestBody
     * @returns SolveMazeResultDto OK
     * @throws ApiError
     */
    public static postSolve(
        requestBody?: Array<Array<number>>,
    ): CancelablePromise<SolveMazeResultDto> {
        return __request(OpenAPI, {
            method: 'POST',
            url: '/solve',
            body: requestBody,
            mediaType: 'application/json',
        });
    }
}
