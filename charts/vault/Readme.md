helm install vault hashicorp/vault --namespace vault --version 0.23.0 -f override-values.yml --dry-run

[//]: # (Unseal Key 1: weVxb8VC2SCzXaHsFzeHVhWFdoc2YEzrwpAInjs6cjU=)

[//]: # ()
[//]: # ()
[//]: # (Initial Root Token: hvs.yTDI8GFR6fOVqm0gY4jjtIhr)


Unseal Key: RL1Tjd+4005vVfo+bSr+628qzvzARgVKNFGIywQvuCs=
Root Token: root



https://habr.com/ru/company/nixys/blog/545188/

``` bash
kubectl exec -ti vault-0 /bin/sh

vi /home/vault/app-policy.hcl

cat < /home/vault/app-policy.hcl
path "secret*" {
capabilities = ["read"]
}
EOF

vault policy write app /home/vault/app-policy.hcl

vault auth enable kubernetes

vault write auth/kubernetes/config \
token_reviewer_jwt="$(cat /var/run/secrets/kubernetes.io/serviceaccount/token)" \
kubernetes_host=https://${KUBERNETES_PORT_443_TCP_ADDR}:443 \
kubernetes_ca_cert=@/var/run/secrets/kubernetes.io/serviceaccount/ca.crt

vault write auth/kubernetes/role/myapp \
bound_service_account_names=app \
bound_service_account_namespaces=demo \
policies=app \
ttl=1h

vault kv put secret/helloworld username=foobaruser password=foobarbazpass

```




