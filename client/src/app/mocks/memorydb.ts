import { InMemoryDbService, RequestInfo, RequestInfoUtilities, ParsedRequestUrl } from 'angular-in-memory-web-api';
import { Catalog } from '../services/models/Catalog';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';
import { delay } from 'rxjs/operators';

@Injectable()
export class MemoryDb implements InMemoryDbService {
  createDb(reqInfo?: RequestInfo): {} | Observable<{}> | Promise<{}> {
    const catalogs: Catalog[] = [
      { id: 1, name: 'root1', parent: null },
      { id: 2, name: 'root2', parent: null },
      { id: 3, name: 'child2.1', parent: 2 },
    ];

    const db = { catalogs };

    let returnType = 'object';

    if (reqInfo) {
      const body = reqInfo.utils.getJsonBody(reqInfo.req) || {};

      // TODO: add saving

      returnType = body.returnType || 'object';
    }

    switch (returnType) {
      case ('observable'):
        return Observable.of(db).pipe(delay(10));
      case ('promise'):
        return new Promise(resolve => {
          setTimeout(() => resolve(db), 10);
        });
      default:
        return db;
    }
  }

  parseRequestUrl(url: string, requestInfoUtils: RequestInfoUtilities): ParsedRequestUrl {
    console.log(url, requestInfoUtils);
    const parsed: ParsedRequestUrl = requestInfoUtils.parseRequestUrl(url);

    if (parsed.collectionName === 'catalogs') {
      parsed.query.set('parent' , [ !parsed.id ? null : parsed.id.toString() ]);
        parsed.id = null;
    }

    return parsed;
  }
}
